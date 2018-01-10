using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace kyokuFind
{
    class LuceneService
    {
        private IndexWriter writer;
        private Directory luceneIndexDirectory;
        private Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
        private Console console;
        //used for reporting progress while indexing
        private System.ComponentModel.BackgroundWorker bgWorker;
        public enum DocType { SONG, ARTIST, ALBUM, GENRE };

        //field constants
        public const string F_ARTIST = "artist";
        public const string F_ALBUM = "album";
        public const string F_FILENAME = "filename";
        public const string F_GENRE = "genre";
        public const string F_TITLE = "title";
        public const string F_YEAR = "year";
        public const string F_NSONGS = "nsongs";
        public const string F_LENGTH = "length";
        public const string F_DOCTYPE = "doctype";

        public LuceneService(Console console)
        {
            luceneIndexDirectory = FSDirectory.Open(CONFIG.LUCENE_INDEX_PATH);
            this.console = console;
        }

        /// <summary>
        /// Returns true if the path specified by CONFIG.LUCENE_INDEX_PATH already
        /// contains an index.
        /// </summary>
        public bool IndexExists()
        {
            return System.IO.Directory.Exists(CONFIG.LUCENE_INDEX_PATH);
        }

        //(re)builds index from a set of results, overwrite is on!
        //FOUR TYPES of documents: songs, artists, albums and genres. field doctype used for distinction.
        public void BuildIndex(IEnumerable<Result> songs)
        {
            //rebuild index if it already exists
            if (IndexExists())
            {
                Debug.WriteLine("deleting index folder...");
                System.IO.Directory.Delete(CONFIG.LUCENE_INDEX_PATH, true);
            }
            luceneIndexDirectory = FSDirectory.Open(CONFIG.LUCENE_INDEX_PATH);
            writer = new IndexWriter(luceneIndexDirectory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
            Debug.WriteLine("rebuilding index...");

            //we use concurrent dictionarys tu support updating
            var dicArtists = new ConcurrentDictionary <string, int>();
            var dicAlbums = new ConcurrentDictionary <string, int>();
            var dicGenres = new ConcurrentDictionary <string, int>();
            //number of documents processed
            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            Debug.WriteLine("adding songs...");

            //first set of documents: songs
            foreach (var song in songs)
            {
                var doc = new Document();
                doc.Add(new Field(F_ARTIST, song.Artist, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field(F_ALBUM, song.Album, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field(F_FILENAME, song.Filename, Field.Store.YES, Field.Index.NOT_ANALYZED));
                doc.Add(new Field(F_GENRE, song.Genre, Field.Store.YES, Field.Index.ANALYZED));
                //if we need to display it
                doc.Add(new Field(F_LENGTH, song.Length, Field.Store.YES, Field.Index.NO));
                doc.Add(new Field(F_TITLE, song.Title, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field(F_YEAR, song.Year, Field.Store.YES, Field.Index.NOT_ANALYZED));
                //to differentiate document types
                doc.Add(new Field(F_DOCTYPE, DocType.SONG.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));

                //we add the artist to our dictionary, if it already exists we increment the number of songs
                dicArtists.AddOrUpdate(song.Artist, 1, (artist, numSongs) => numSongs += 1);
                dicAlbums.AddOrUpdate(song.Album, 1, (album, numSongs) => numSongs += 1);
                dicGenres.AddOrUpdate(song.Genre, 1, (genre, numSongs) => numSongs += 1);

                writer.AddDocument(doc);
            }
            //second set of documents: artists
            Debug.WriteLine("adding artists...");
            foreach (var artist in dicArtists)
            {
                var doc = new Document();
                doc.Add(new Field(F_ARTIST, artist.Key, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field(F_NSONGS, artist.Value.ToString(), Field.Store.YES, Field.Index.NO));
                //to differentiate document types
                doc.Add(new Field(F_DOCTYPE, DocType.ARTIST.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                writer.AddDocument(doc);
            }
            //third set of documents: albums
            Debug.WriteLine("adding albums...");
            foreach (var album in dicAlbums)
            {
                var doc = new Document();
                doc.Add(new Field(F_ALBUM, album.Key, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field(F_NSONGS, album.Value.ToString(), Field.Store.YES, Field.Index.NO));
                //to differentiate document types
                doc.Add(new Field(F_DOCTYPE, DocType.ALBUM.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                writer.AddDocument(doc);
            }
            //third set of documents: genres
            Debug.WriteLine("adding genres...");
            foreach (var genre in dicGenres)
            {
                var doc = new Document();
                doc.Add(new Field(F_GENRE, genre.Key, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field(F_NSONGS, genre.Value.ToString(), Field.Store.YES, Field.Index.NO));
                //to differentiate document types
                doc.Add(new Field(F_DOCTYPE, DocType.GENRE.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                writer.AddDocument(doc);
            }

            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
            timer.Stop();

            Debug.WriteLine("Index built succesfully!");
        }

        //searches the four types of objects and returns the results as four list parameters
        public void Search(string searchTerm, ref IEnumerable<Result> songs, ref IEnumerable<Result> artists,
            ref IEnumerable<Result> albums, ref IEnumerable<Result> genres)
        {
            albums = Search(F_ALBUM, searchTerm);
            songs = Search(F_TITLE, searchTerm);
            artists = Search(F_ARTIST, searchTerm);
            genres = Search(F_GENRE, searchTerm);
        }

        //Main search algorithm
        public IEnumerable<Result> Search(string fieldName, string searchTerm)
        {
            DocType docType = DocType.SONG;
            Query mainQuery;
            switch(fieldName)
            {
                case F_ARTIST:
                    docType=DocType.ARTIST;
                    break;
                case F_ALBUM:
                    docType=DocType.ALBUM;
                    break;
                case F_GENRE:
                    docType=DocType.GENRE;
                    break;
            }
            IndexSearcher searcher = new IndexSearcher(luceneIndexDirectory);
            BooleanQuery booleanQuery = new BooleanQuery();
            QueryParser qp = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, fieldName, analyzer);
            try
            {
                mainQuery = qp.Parse(searchTerm);
            }
            catch (ParseException e)
            {
                console.Log(e.Message);
                return null;
            }
            Query DocTypeQuery = new TermQuery(new Term(F_DOCTYPE, docType.ToString()));
            booleanQuery.Add(mainQuery, Occur.MUST);
            booleanQuery.Add(DocTypeQuery, Occur.MUST);
            console.Log("query: " + booleanQuery.ToString());
            TopDocs hitsFound = searcher.Search(booleanQuery , Int32.MaxValue);
            List<Result> results = new List<Result>();
            Result sampleResult = null;

            for (int i = 0; i < hitsFound.TotalHits; i++)
            {
                sampleResult = new Result();
                Document doc = searcher.Doc(hitsFound.ScoreDocs[i].Doc);
                //key moment
                fillResult(sampleResult, fieldName, doc);
                float score = hitsFound.ScoreDocs[i].Score;
                sampleResult.Score = score;
                results.Add(sampleResult);
            }
            return results.OrderByDescending(x => x.Score).ToList();
        }

        //sets the values of a Result object according to the resultType specified.
        //This is because different documents have different fields
        private Result fillResult(Result sampleResult, string resultType, Document doc)
        {
            switch (resultType)
            {
                case F_ARTIST:
                    sampleResult.Artist = doc.Get(F_ARTIST);
                    sampleResult.nSongs = doc.Get(F_NSONGS);
                    break;
                case F_ALBUM:
                    sampleResult.Album = doc.Get(F_ALBUM);
                    sampleResult.nSongs = doc.Get(F_NSONGS);
                    break;
                case F_GENRE:
                    sampleResult.Genre = doc.Get(F_GENRE);
                    sampleResult.nSongs = doc.Get(F_NSONGS);
                    break;
                case F_TITLE:
                    sampleResult.Title = doc.Get(F_TITLE);
                    sampleResult.Artist = doc.Get(F_ARTIST);
                    sampleResult.Genre = doc.Get(F_GENRE);
                    sampleResult.Album = doc.Get(F_ALBUM);
                    sampleResult.Year = doc.Get(F_YEAR);
                    sampleResult.Filename = doc.Get(F_FILENAME);
                    break;
            }
            return sampleResult;
        }
    }
}

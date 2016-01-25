kyokuFind requires .NET 4.0 to run. You shouldn't need anything else for compiling since the libraries are included. The project files was created in Visual Studio 2012, though.

These paths are of interest to you:
-LuceneService.indexPath;
    This is where the Lucene Index will be saved.
-Mp3Tags.musicPath;
    This is the folder containing the music you want to index.

hotkeys:

-press ENTER to search
-to clear results just delete query and press ENTER
-To (re)build the index: Ctrl+R
-To clear the console: Ctrl+L
-To create a playlist of the results: Ctrl+P

special queries:

-search similar artist
    !similarto Billie Holiday
-info about similar artist
    double click the artist and it will take you to their homepage (only after !similarto query)
-get songs by (multiple) artists
    !songsby ella fitzgerald, billie holiday, duke ellington
-get the songs of (multiple) albums
    !songsin lady sings the blues, the golden years, live on verve
-get the songs of (multiple) genres
    bossa nova, jazz, blues !songs
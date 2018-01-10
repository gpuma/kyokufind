# kyokuFind

kyokuFind is a local music library application for Windows, written in C# using the Lucene Search Engine library.

![Demo kyokuFind](https://i.imgur.com/mFOLIAY.gif)

## Limitations

- Currently works on mp3 files only.
- kyokuFind **is not** a media player; it creates playlists that are opened by your default media player.

## Compiling and running the project

- Clone the repo: `git clone https://github.com/gpuma/kyokufind`
- Open **kyokuFind.sln** on **Visual Studio** (Tested on VS2017 Community)
- Install Nuget packages: `nuget install packages.config`
- Open **kyokuFind/config.ini** and set `INDEX_PATH` to the folder path you want the program to build or read the index from.
- **(OPTIONAL)** If you want to use recommendation queries you need to enter Last.fm API credentials in **config.ini**. You can get yours [here](https://www.last.fm/api).
- Run the project

## Usage

- Select the folder where your music library is located and then kyokuFind will start building the index at the location specified at **config.INI**
- Enter your query and press `ENTER` to search.
- Enter an empty query it will return all documents
- To clear the console: `Ctrl+L`
- To rebuild the index: `Ctrl+R`
- Double click any song to start playing it

#### Special queries
- To get songs by artist(s): `!songsby artist1, artist2...`. Example:

![songsby operator example](https://imgur.com/ICwXY7R.gif)

- To get songs by album name(s): `!songsin album1, album2...`. Example:

![songsin operator example](https://i.imgur.com/DrJ3YbB.gif)

- To get songs by genre(s): `!songs album1, album2...`. Example:

![songs operator example](https://i.imgur.com/13e8yzr.gif)

- To find similar artists (recommendation query): `!similarto artist`. Double click on the artist results to open its last.fm page. Example:

![similarto operator example](https://i.imgur.com/jDC4Jgh.gif)

## Libraries included in the project

- [lastfm-sharp](https://code.google.com/archive/p/lastfm-sharp/)
- UltraId3Lib
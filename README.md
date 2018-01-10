## kyokuFind

kyokuFind is a local music library application for Windows, written in C# using the Lucene library. 

#### Usage

- Select the folder where your music library is located and then kyokuFind will start building the index at the location specified at **config.INI**
- Enter your query and press ENTER to search.
- Enter an empty query it will return all documents
- To create a playlist of the resulting songs and start playing it: `Ctrl+P`
- To clear the console: `Ctrl+R`

#### Special queries
- To get songs by artist(s): `!songsby artist1, artist2`
![songsby example]({{site.baseurl}}/https://imgur.com/ICwXY7R.gif)

#### Other shortcuts

#### Compiling and running the project

- Clone the repo: `git clone https://github.com/gpuma/kyokufind`
- Open kyokuFind.sln on Visual Studio
- Install Nuget packages: `nuget install packages.config`
- Open kyokuFind/config.ini and set `INDEX_PATH` to the folder path you want the program to build or read the index from.
- (OPTIONAL) If you want to use recommendation queries you need to enter Last.fm API credentials at config.ini. You can get yours [here](https://www.last.fm/api).
- Run the project

#### Libraries included in the project

- [lastfm-sharp](https://code.google.com/archive/p/lastfm-sharp/)
- UltraId3Lib

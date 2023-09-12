<Query Kind="Program">
  <Connection>
    <ID>6a41590a-8c3a-4bbe-b4ef-d9fec869cbd4</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//  Used to load the SongView models from the classes folder
#load ".\ViewModels\*.cs"
void Main()
{
	//  Strongly type query set 

	//  Anonymous dataset from a query does NOT have a permanent  
	//   specified class definition (dynamic). 
	//  Strongly type query dataset HAS a permanent class definition 
	//   in its code. 

	//  Find all songs containing a partial track name string. 
	//  Display the Album, Song (Track Name), and Artist. 

	//  Image your solutions need to mimic a web app query to some  
	//   BLL service. 

	string partialSongName = "dance";
	
	//	anonymous dataset
	IEnumerable anonymousTypeResults = AnonymousTypeSongByPartialName(partialSongName);
	anonymousTypeResults.Dump();

	//  strongly type dataset
	List<SongView> stronglyTypeResults = StronglyTypeSongByPartialName(partialSongName);
	stronglyTypeResults.Dump();

}

//	anonymous dataset
private IEnumerable AnonymousTypeSongByPartialName(string partialSongName)
{
	var songCollection =
	Tracks
		  .Where(x => x.Name.Contains(partialSongName))
		  .Select(x => new 
		  {
			  AlbumTitle = x.Album.Title, //  We are using the navigation property 
			  SongTitle = x.Name,
			  Artist = x.Album.Artist.Name  //  We are using the navigation property 
		  });
	return songCollection;
}




//	to change the anonymous dataset to a strongly type dataset 
//  add the datatype Song to the instance creation operator (new) 
private List<SongView> StronglyTypeSongByPartialName(string partialSongName)
{
	var songCollection =
	Tracks
		  .Where(x => x.Name.Contains(partialSongName))
		  .Select(x => new SongView
		  {
			  AlbumTitle = x.Album.Title, //  We are using the navigation property 
			  SongTitle = x.Name,
			  Artist = x.Album.Artist.Name  //  We are using the navigation property 
		  });
	return songCollection.ToList();
}
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Repositories;

public class MovieRankRepository : IMovieRankRepository
{
    public async Task<IEnumerable<MovieDb>> GetAllItemsAsync()
    {
        List<MovieDb> list = new List<MovieDb>();
        
        list.Add(new MovieDb()
        {
            MovieName = "The Departed",
            Description = "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in South Boston."
        });
        list.Add(new MovieDb()
        {
            MovieName = "Inglourious Basterds",
            Description = "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same."
            
        });
        list.Add(new MovieDb()
        {
            MovieName = "Gone Girl",
            Description = "With his wife's disappearance having become the focus of an intense media circus, a man sees the spotlight turned on him when it's suspected that he may not be innocent."
        });

        return await Task.FromResult<IEnumerable<MovieDb>>(list);
    }
}
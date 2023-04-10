using MovieRank.Contracts;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repositories;

namespace MovieRank.Services;

public class MovieRankService : IMovieRankService
{
    private readonly IMovieRankRepository _movieRankRepository;
    private readonly IMapper _mapper;

    public MovieRankService(IMovieRankRepository movieRankRepository,
        IMapper mapper)
    {
        _movieRankRepository = movieRankRepository ?? throw new ArgumentNullException(nameof(movieRankRepository));
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieResponse>> GetAllItemsAsync()
    {
        var response = await _movieRankRepository.GetAllItemsAsync();
        return _mapper.ToMovieContract(response);
    }
    
    public async Task<MovieResponse> GetMovieAsync(int userId, string movieName)
    {
        var response = await _movieRankRepository.GetMovieAsync(userId, movieName);
        return _mapper.ToMovieContract(response);
    }

    public async Task<IEnumerable<MovieResponse>> GetUserRankedMoviesByTitleAsync(int userId, string movieName)
    {
        var response = await _movieRankRepository.GetUserRankedMoviesByTitleAsync(userId, movieName);
        return _mapper.ToMovieContract(response);
    }

    public async Task AddMovieAsync(int userId, MovieRankRequest movieRankRequest)
    {
        var movieDb = _mapper.ToMovieDbModel(userId, movieRankRequest);
        await _movieRankRepository.AddMovieAsync(movieDb);
    }
}
using AlbumRank.Contracts;
using AlbumRank.Libs.Mappers;
using AlbumRank.Libs.Repositories;

namespace AlbumRank.Services;

public class AlbumRankService : IAlbumRankService
{
    private readonly IAlbumRankRepository _albumRankRepository;
    private readonly IMapper _mapper;

    public AlbumRankService(IAlbumRankRepository albumRankRepository,
        IMapper mapper)
    {
        _albumRankRepository = albumRankRepository ?? throw new ArgumentNullException(nameof(albumRankRepository));
        _mapper = mapper;
    }    
    
    public async Task<IEnumerable<AlbumResponse>> GetAllItems()
    {
        var response = await _albumRankRepository.GetAllItemsFromDb();
        return _mapper.ToAlbumContract(response);
    }

    public async Task<AlbumResponse> GetAlbum(int userId, string title)
    {
        var response = await _albumRankRepository.GetAlbum(userId, title);
        return _mapper.ToAlbumContract(response);
    }

    public async Task<IEnumerable<AlbumResponse>> GetUserRankedAlbumByTitle(int userId, string title)
    {
        var response = await _albumRankRepository.GetUsersRankedAlbumsByTitle(userId, title);
        return _mapper.ToAlbumContract(response);
    }

    public async Task AddAlbum(int userId, AlbumRankRequest albumRankRequest)
    {
        var albumDb = _mapper.ToAlbumDbModel(userId, albumRankRequest);
        await _albumRankRepository.AddAlbum(albumDb);
    }

    public async Task UpdateAlbum(int userId, AlbumUpdateRequest request)
    {
        var response = await _albumRankRepository.GetAlbum(userId, request.Title);
        var albumDb = _mapper.ToAlbumDbModel(userId, response, request);
        await _albumRankRepository.UpdateAlbum(albumDb);
    }

    public async Task<AlbumRankResponse> GetAlbumRank(string title)
    {
        var response = await _albumRankRepository.GetAlbumRank(title);

        var avgRanking = Math.Round(response.Select(x =>
        {
            Console.WriteLine(x.Ranking);
            return x.Ranking;
        }).Average());

        return new AlbumRankResponse
        {
            Title = title,
            OverallRanking = avgRanking
        };
    }
}
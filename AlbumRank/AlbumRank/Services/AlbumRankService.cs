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
}
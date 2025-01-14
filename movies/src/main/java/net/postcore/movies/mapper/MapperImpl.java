package net.postcore.movies.mapper;

import net.postcore.movies.domain.Movie;
import net.postcore.movies.models.MovieDto;
import org.springframework.stereotype.Component;

@Component
public class MapperImpl implements Mapper {
    @Override
    public MovieDto toMovieDto(Movie movie) {
        var movieDto = new MovieDto();
        movieDto.setId(movie.getId());
        movieDto.setImdbId(movie.getImdbId());
        movieDto.setTitle(movie.getTitle());
        movieDto.setReleaseDate(movie.getReleaseDate());
        movieDto.setTrailerLink(movie.getTrailerLink());
        movieDto.setPoster(movie.getPoster());
        movieDto.setBackdrops(movie.getBackdrops());
        movieDto.setGenres(movie.getGenres());
        movieDto.setReviews(movie.getReviews());
        return movieDto;
    }
}

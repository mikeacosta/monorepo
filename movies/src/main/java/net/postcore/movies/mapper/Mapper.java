package net.postcore.movies.mapper;

import net.postcore.movies.domain.Movie;
import net.postcore.movies.models.MovieDto;

public interface Mapper {
    MovieDto toMovieDto(Movie movie);
}

package net.postcore.movies.services;

import net.postcore.movies.domain.Movie;

import java.util.List;
import java.util.Optional;

public interface MoviesService {
    List<Movie> getMovies();
    Optional<Movie> getMovieByImdbId(String imdbId);
}

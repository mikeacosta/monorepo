package net.postcore.movies.services;

import net.postcore.movies.domain.Movie;

import java.util.List;

public interface MoviesService {
    List<Movie> getMovies();
}

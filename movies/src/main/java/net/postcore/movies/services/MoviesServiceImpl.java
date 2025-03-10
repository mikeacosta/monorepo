package net.postcore.movies.services;

import net.postcore.movies.domain.Movie;
import net.postcore.movies.repos.MoviesRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class MoviesServiceImpl implements MoviesService {

    private final MoviesRepository moviesRepository;

    public MoviesServiceImpl(MoviesRepository moviesRepository) {
        this.moviesRepository = moviesRepository;
    }

    public List<Movie> getMovies() {
        return moviesRepository.findAll();
    }

    public Optional<Movie> getMovieByImdbId(String imdbId) {
        return moviesRepository.findMovieByImdbId(imdbId);
    }
}
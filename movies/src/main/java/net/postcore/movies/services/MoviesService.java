package net.postcore.movies.services;

import net.postcore.movies.domain.Movie;
import net.postcore.movies.repos.MoviesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class MoviesService {

    @Autowired
    private MoviesRepository moviesRepository;

    public MoviesService(MoviesRepository moviesRepository) {
        this.moviesRepository = moviesRepository;
    }

    public List<Movie> getMovies() {
        return moviesRepository.findAll();
    }
}

package net.postcore.movies.controllers;

import net.postcore.movies.models.MovieDto;
import net.postcore.movies.services.MoviesService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/api/v1/movies")
public class MoviesController {

    @Autowired
    private MoviesService moviesService;

//    public MoviesController(MoviesService moviesService) {
//        this.moviesService = moviesService;
//    }

    @GetMapping
    public ResponseEntity<List<MovieDto>> getAllMovies() {
        var movies = moviesService.getMovies();
        var response = movies.stream().map(movie -> {
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
        }).collect(Collectors.toList());
        return new ResponseEntity<>(response, HttpStatus.OK);
    }
}

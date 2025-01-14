package net.postcore.movies.controllers;

import net.postcore.movies.mapper.Mapper;
import net.postcore.movies.models.MovieDto;
import net.postcore.movies.services.MoviesService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/api/v1/movies")
public class MoviesController {

    private final MoviesService moviesService;

    private final Mapper mapper;

    public MoviesController(MoviesService moviesService, Mapper mapper) {
        this.moviesService = moviesService;
        this.mapper = mapper;
    }

    @GetMapping
    public ResponseEntity<List<MovieDto>> getAllMovies() {
        var movies = moviesService.getMovies();
        var response = movies.stream().map(mapper::toMovieDto)
                .collect(Collectors.toList());
        return new ResponseEntity<>(response, HttpStatus.OK);
    }
}

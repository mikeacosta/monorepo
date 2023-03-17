package net.postcore.languagesapi.controllers;

import net.postcore.languagesapi.api.model.LanguageDto;
import net.postcore.languagesapi.services.LanguageService;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping(LanguageController.BASE_URL)
public class LanguageController {

    public static final String BASE_URL = "/api/languages";
    private final LanguageService languageService;

    public LanguageController(LanguageService languageService) {
        this.languageService = languageService;
    }

    @GetMapping
    @ResponseStatus(HttpStatus.OK)
    public List<LanguageDto> getAllLanguages(){
        return languageService.getAllLanguages();
    }
}

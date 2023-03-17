package net.postcore.languagesapi.services;

import net.postcore.languagesapi.api.model.LanguageDto;

import java.util.List;

public interface LanguageService {

    List<LanguageDto> getAllLanguages();
}

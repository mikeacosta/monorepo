package net.postcore.languagesapi.services;

import net.postcore.languagesapi.api.mapper.LanguageMapper;
import net.postcore.languagesapi.api.model.LanguageDto;
import net.postcore.languagesapi.repositories.LanguageRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class LanguageServiceImpl implements LanguageService {

    private final LanguageMapper languageMapper;
    private final LanguageRepository languageRepository;

    public LanguageServiceImpl(LanguageMapper languageMapper, LanguageRepository languageRepository) {
        this.languageMapper = languageMapper;
        this.languageRepository = languageRepository;
    }

    @Override
    public List<LanguageDto> getAllLanguages() {
        return languageRepository.findAll()
                .stream()
                .map(languageMapper::languageToLanguageDto)
                .collect(Collectors.toList());
    }
}

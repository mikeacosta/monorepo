package net.postcore.languagesapi.api.mapper;

import net.postcore.languagesapi.api.model.LanguageDto;
import net.postcore.languagesapi.domain.Language;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class LanguageMapperTest {

    @Test
    public void languageToLanguageDto() throws Exception {
        Language language = new Language();
        language.setName("English");
        language.setFamily("Indo-European");
        language.setSpeakers(1452);

        LanguageMapper languageMapper = LanguageMapper.INSTANCE;
        LanguageDto languageDto = languageMapper.languageToLanguageDto(language);

        assertEquals(language.getName(), languageDto.getName());
        assertEquals(language.getFamily(), languageDto.getFamily());
        assertEquals(language.getSpeakers(), languageDto.getSpeakers());
    }

}
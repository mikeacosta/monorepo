package net.postcore.languagesapi.api.mapper;

import net.postcore.languagesapi.api.model.LanguageDto;
import net.postcore.languagesapi.domain.Language;
import org.mapstruct.Mapper;
import org.mapstruct.factory.Mappers;

@Mapper
public interface LanguageMapper {

    LanguageMapper INSTANCE = Mappers.getMapper(LanguageMapper.class);

    LanguageDto languageToLanguageDto(Language language);
}

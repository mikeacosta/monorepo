package net.postcore.apilist.cli.service;

import org.apache.commons.validator.routines.UrlValidator;

public record PublicApi(String API, String Description, String Auth, Boolean HTTPS, String Cors, String Link, String Category) {

    public boolean isLinkValid() {
        String[] schemes = {"http","https"};
        UrlValidator urlValidator = new UrlValidator(schemes);
        return urlValidator.isValid(Link);
    }
}

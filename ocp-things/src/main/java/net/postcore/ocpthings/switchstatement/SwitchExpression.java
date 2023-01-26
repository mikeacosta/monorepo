package net.postcore.ocpthings.switchstatement;

public class SwitchExpression {

    public static String getRatingDescription(char rating) {
        return switch(rating) {
            case 'a':
                yield "great";
            case 'b':
                yield "good";
            case 'c' | 'd':
                yield "fair";
            default:
                yield "poor";
        };
    }
}

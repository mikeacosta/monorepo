package net.postcore.ocpthings.anonsubclassenum;

public class AnonSubclassEnum {

    public static String whenIsTheNextSpringOne() {
        return Conference.SPRING_ONE.whenIsTheNext();
    }

    public static String whenIsTheNextDevoxxUk() {
        return Conference.DEVOXX_UK.whenIsTheNext();
    }

    public static String whenIsTheNextJavaWorld() {
        return Conference.JAVA_WORLD.whenIsTheNext();
    }
}

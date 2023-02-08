package net.postcore.crittercare.service;

import net.postcore.crittercare.model.Critter;

import java.util.Set;

public interface CritterService {

    Critter findById(Long id);

    Critter save(Critter critter);

    Set<Critter> findAll();
}

package net.postcore.crittercare.service.map;

import net.postcore.crittercare.model.Critter;
import net.postcore.crittercare.service.CritterService;
import org.springframework.stereotype.Service;

import java.util.Set;

@Service
public class CritterServiceMap extends AbstractMapService<Critter, Long> implements CritterService {
    
    @Override
    public Set<Critter> findAll() {
        return super.findAll();
    }

    @Override
    public Critter findById(Long id) {
        return super.findById(id);
    }

    @Override
    public Critter save(Critter object) {
        return super.save(object.getId(), object);
    }

    @Override
    public void delete(Critter object) {
        super.delete(object);
    }

    @Override
    public void deleteById(Long id) {
        super.deleteById(id);
    }
}
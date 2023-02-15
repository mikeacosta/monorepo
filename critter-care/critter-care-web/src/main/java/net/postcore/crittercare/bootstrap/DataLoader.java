package net.postcore.crittercare.bootstrap;

import net.postcore.crittercare.model.Owner;
import net.postcore.crittercare.model.Vet;
import net.postcore.crittercare.service.OwnerService;
import net.postcore.crittercare.service.VetService;
import net.postcore.crittercare.service.map.OwnerServiceMap;
import net.postcore.crittercare.service.map.VetServiceMap;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

@Component
public class DataLoader implements CommandLineRunner {

    private final OwnerService ownerService;
    private final VetService vetService;

    public DataLoader() {
        this.ownerService = new OwnerServiceMap();
        this.vetService = new VetServiceMap();
    }

    @Override
    public void run(String... args) throws Exception {
        Owner owner1 = new Owner();
        owner1.setFirstName("Bugs");
        owner1.setLastName("Bunny");

        ownerService.save(owner1);

        Owner owner2 = new Owner();
        owner2.setFirstName("Homer");
        owner2.setLastName("Simpson");

        ownerService.save(owner2);

        System.out.println("loaded owners...");

        Vet vet1 = new Vet();
        vet1.setFirstName("Mickey");
        vet1.setLastName("Mouse");

        vetService.save(vet1);

        Vet vet2 = new Vet();
        vet2.setFirstName("Charlie");
        vet2.setLastName("Brown");

        vetService.save(vet2);

        System.out.println("loaded vets....");
    }
}

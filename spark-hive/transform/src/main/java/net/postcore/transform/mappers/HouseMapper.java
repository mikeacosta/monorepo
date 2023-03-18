package net.postcore.transform.mappers;

import net.postcore.transform.models.House;
import org.apache.spark.api.java.function.MapFunction;
import org.apache.spark.sql.Row;

import java.text.SimpleDateFormat;

public class HouseMapper implements MapFunction<Row, House> {

    @Override
    public House call(Row row) throws Exception {
        House house = new House();
        house.setId(row.getAs("id"));
        house.setAddress(row.getAs("address"));
        house.setSqft(row.getAs("sqft"));
        house.setPrice(row.getAs("price"));

        String vacantBy = row.getAs("vacantBy").toString();
        System.out.println(vacantBy);

        if (vacantBy != null) {
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
            house.setVacantBy(format.parse(vacantBy));
        }

        return house;
    }
}

package dao;

import javax.persistence.*;

import entity.*;

public class CityDAO extends GenericDAO<City, Integer> {

	public CityDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
package dao;

import javax.persistence.*;

import entity.*;

public class CountryDAO extends GenericDAO<Country, Integer> {

	public CountryDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
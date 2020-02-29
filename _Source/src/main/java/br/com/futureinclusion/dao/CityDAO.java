package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class CityDAO extends GenericDAO<City, Integer> {

	public CityDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
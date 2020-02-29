package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class CountryDAO extends GenericDAO<Country, Integer> {

	public CountryDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
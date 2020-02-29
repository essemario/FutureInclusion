package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class PowerDAO extends GenericDAO<Power, Integer> {

	public PowerDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
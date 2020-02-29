package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class StateDAO extends GenericDAO<State, Integer> {

	public StateDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
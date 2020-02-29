package dao;

import javax.persistence.*;

import entity.*;

public class StateDAO extends GenericDAO<State, Integer> {

	public StateDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
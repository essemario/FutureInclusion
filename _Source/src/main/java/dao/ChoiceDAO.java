package dao;

import javax.persistence.*;

import entity.*;

public class ChoiceDAO extends GenericDAO<Choice, Integer> {

	public ChoiceDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
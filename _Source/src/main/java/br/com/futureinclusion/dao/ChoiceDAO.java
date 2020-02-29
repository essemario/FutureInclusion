package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class ChoiceDAO extends GenericDAO<Choice, Integer> {

	public ChoiceDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
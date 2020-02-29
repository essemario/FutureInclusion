package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class PollDAO extends GenericDAO<Poll, Integer> {

	public PollDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
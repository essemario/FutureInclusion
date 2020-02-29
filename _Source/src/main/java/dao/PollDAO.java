package dao;

import javax.persistence.*;

import entity.*;

public class PollDAO extends GenericDAO<Poll, Integer> {

	public PollDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
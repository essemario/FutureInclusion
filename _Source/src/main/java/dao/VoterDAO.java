package dao;

import javax.persistence.*;

import entity.*;

public class VoterDAO extends GenericDAO<Voter, Integer> {

	public VoterDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
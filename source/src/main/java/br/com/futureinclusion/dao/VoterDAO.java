package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class VoterDAO extends GenericDAO<Voter, Integer> {

	public VoterDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class ImageDAO extends GenericDAO<Image, Integer> {

	public ImageDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}
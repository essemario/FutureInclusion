package br.com.futureinclusion.entity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


/**
 * The persistent class for the Choice database table.
 * 
 */
@Entity
@NamedQuery(name="Choice.findAll", query="SELECT c FROM Choice c")
public class Choice implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int id;

	@Lob
	private String text;

	//bi-directional many-to-one association to Poll
	@ManyToOne
	private Poll poll;

	//bi-directional many-to-many association to Voter
	@ManyToMany(mappedBy="choices")
	private List<Voter> voters;

	public Choice() {
	}

	public int getId() {
		return this.id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getText() {
		return this.text;
	}

	public void setText(String text) {
		this.text = text;
	}

	public Poll getPoll() {
		return this.poll;
	}

	public void setPoll(Poll poll) {
		this.poll = poll;
	}

	public List<Voter> getVoters() {
		return this.voters;
	}

	public void setVoters(List<Voter> voters) {
		this.voters = voters;
	}

}
package br.com.futureinclusion.entity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


/**
 * The persistent class for the Voter database table.
 * 
 */
@Entity
@NamedQuery(name="Voter.findAll", query="SELECT v FROM Voter v")
public class Voter implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int id;

	private String document;

	private String email;

	private byte enabled;

	@Column(name="last_name")
	private String lastName;

	private String name;

	private String password;

	//bi-directional many-to-one association to Image
	@ManyToOne
	private Image image;

	//bi-directional many-to-many association to Mandate
	@ManyToMany(mappedBy="voters")
	private List<Mandate> mandates;

	//bi-directional many-to-many association to Choice
	@ManyToMany
	@JoinColumn(name="id")
	private List<Choice> choices;

	public Voter() {
	}

	public int getId() {
		return this.id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getDocument() {
		return this.document;
	}

	public void setDocument(String document) {
		this.document = document;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public byte getEnabled() {
		return this.enabled;
	}

	public void setEnabled(byte enabled) {
		this.enabled = enabled;
	}

	public String getLastName() {
		return this.lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPassword() {
		return this.password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public Image getImage() {
		return this.image;
	}

	public void setImage(Image image) {
		this.image = image;
	}

	public List<Mandate> getMandates() {
		return this.mandates;
	}

	public void setMandates(List<Mandate> mandates) {
		this.mandates = mandates;
	}

	public List<Choice> getChoices() {
		return this.choices;
	}

	public void setChoices(List<Choice> choices) {
		this.choices = choices;
	}

}
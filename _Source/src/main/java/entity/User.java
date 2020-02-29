package entity;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the User database table.
 * 
 */
@Entity
@NamedQuery(name="User.findAll", query="SELECT u FROM User u")
public class User implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int id;

	private byte enabled;

	@Column(name="last_name")
	private String lastName;

	private byte level;

	private String name;

	//bi-directional many-to-one association to Image
	@ManyToOne
	private Image image;

	//bi-directional many-to-one association to Mandate
	@ManyToOne
	private Mandate mandate;

	public User() {
	}

	public int getId() {
		return this.id;
	}

	public void setId(int id) {
		this.id = id;
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

	public byte getLevel() {
		return this.level;
	}

	public void setLevel(byte level) {
		this.level = level;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Image getImage() {
		return this.image;
	}

	public void setImage(Image image) {
		this.image = image;
	}

	public Mandate getMandate() {
		return this.mandate;
	}

	public void setMandate(Mandate mandate) {
		this.mandate = mandate;
	}

}
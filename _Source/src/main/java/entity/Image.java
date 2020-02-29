package entity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


/**
 * The persistent class for the Image database table.
 * 
 */
@Entity
@NamedQuery(name="Image.findAll", query="SELECT i FROM Image i")
public class Image implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int id;

	@Lob
	private String url;

	//bi-directional many-to-one association to User
	@OneToMany(mappedBy="image")
	private List<User> users;

	//bi-directional many-to-one association to Voter
	@OneToMany(mappedBy="image")
	private List<Voter> voters;

	public Image() {
	}

	public int getId() {
		return this.id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getUrl() {
		return this.url;
	}

	public void setUrl(String url) {
		this.url = url;
	}

	public List<User> getUsers() {
		return this.users;
	}

	public void setUsers(List<User> users) {
		this.users = users;
	}

	public User addUser(User user) {
		getUsers().add(user);
		user.setImage(this);

		return user;
	}

	public User removeUser(User user) {
		getUsers().remove(user);
		user.setImage(null);

		return user;
	}

	public List<Voter> getVoters() {
		return this.voters;
	}

	public void setVoters(List<Voter> voters) {
		this.voters = voters;
	}

	public Voter addVoter(Voter voter) {
		getVoters().add(voter);
		voter.setImage(this);

		return voter;
	}

	public Voter removeVoter(Voter voter) {
		getVoters().remove(voter);
		voter.setImage(null);

		return voter;
	}

}
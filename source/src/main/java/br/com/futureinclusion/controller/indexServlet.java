package br.com.futureinclusion.controller;

import java.io.IOException;
import java.util.Enumeration;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import br.com.futureinclusion.entity.Image;
import br.com.futureinclusion.entity.User;
import br.com.futureinclusion.entity.Voter;

@WebServlet({ "/admin" })
public class indexServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	
	protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		Enumeration<String> paransNames = request.getParameterNames();
        String action = (paransNames.hasMoreElements()) ? paransNames.nextElement() : "home";
        
        request.setAttribute("activeMenu", action);
        request.setAttribute("activeSubMenu", request.getParameter(action));
        
        boolean redirect = false;
        String exitAddress = "";
        
        try {
            switch (action) {
            case "dashboard":
            	exitAddress = "/WEB-INF/view/dashboard.jsp";
            	redirect = true;
                break;
            case "voter":
            	VoterController voterController = new VoterController();

        		if(request.getParameter(action).equals("new")) {
        			exitAddress = "/WEB-INF/view/voter-form.jsp";
                	redirect = true;
        			break;
        		} else if(request.getParameter(action).equals("edit")) {
			        Integer id = getParamInt(request, "id");
        			if(id > 0) {			
	        			Voter voter = voterController.GetOne(id);
	        			if(voter != null) {
		        			request.setAttribute("voter", voter);
		        			exitAddress = "/WEB-INF/view/voter-form.jsp";
		                	redirect = true;
		        			break;
	        			}
			        }
        		} else if(request.getParameter(action).equals("save")) {
        			Voter model = new Voter();
        			
        			model.setId(getParamInt(request, "id"));
        			model.setName(getParamString(request, "first-name"));
        			model.setLastName(getParamString(request, "last-name"));
        			model.setDocument(getParamString(request, "cpf"));
        			model.setEmail(getParamString(request, "email"));
        			model.setPassword(getParamString(request, "password"));
        			model.setEnabled((byte) (getParamString(request, "status").equals("enabled") ? 1 : 0));
        			model.setImage(new Image(1));
        			voterController.Save(model);
        			
        			exitAddress = request.getRequestURI() + "?voter=list";
                	redirect = false;
        			break;
        		} else if(request.getParameter(action).equals("delete")) {
			        Integer id = getParamInt(request, "id");
        			if(id > 0) {
	        			voterController.Delete(id);
	        			exitAddress = request.getRequestURI() + "?voter=list";
	                	redirect = false;
	        			break;
			        }
        		} else if(request.getParameter(action).equals("list")) {
        			request.setAttribute("voters", voterController.GetAll());
        			exitAddress = "/WEB-INF/view/voter-list.jsp";
                	redirect = true;
        			break;
        		}
            case "user":
            	UserController userController = new UserController();

        		if(request.getParameter(action).equals("new")) {
        			exitAddress = "/WEB-INF/view/user-form.jsp";
                	redirect = true;
        			break;
        		} else if(request.getParameter(action).equals("edit")) {
			        Integer id = getParamInt(request, "id");
        			if(id > 0) {			
	        			User user = userController.GetOne(id);
	        			if(user != null) {
		        			request.setAttribute("user", user);
		        			exitAddress = "/WEB-INF/view/user-form.jsp";
		                	redirect = true;
		        			break;
	        			}
			        }
        		} else if(request.getParameter(action).equals("save")) {
        			User model = new User();
        			
        			model.setId(getParamInt(request, "id"));
        			model.setName(getParamString(request, "first-name"));
        			model.setLastName(getParamString(request, "last-name"));
        			model.setEmail(getParamString(request, "email"));
        			model.setPassword(getParamString(request, "password"));
        			model.setEnabled((byte) (getParamString(request, "status").equals("enabled") ? 1 : 0));
        			model.setImage(new Image(1));
        			String level = getParamString(request, "level");
        			model.setLevel((byte) (level.equals("0") ? 0 : (level.equals("1") ? 1 : 2)));
        			userController.Save(model);
        			
        			exitAddress = request.getRequestURI() + "?user=list";
                	redirect = false;
        			break;
        		} else if(request.getParameter(action).equals("delete")) {
			        Integer id = getParamInt(request, "id");
        			if(id > 0) {
	        			userController.Delete(id);
	        			exitAddress = request.getRequestURI() + "?user=list";
	                	redirect = false;
	        			break;
			        }
        		} else if(request.getParameter(action).equals("list")) {
        			request.setAttribute("users", userController.GetAll());
        			exitAddress = "/WEB-INF/view/user-list.jsp";
                	redirect = true;
        			break;
        		}
            	
            	
            	
            	//Gera um NOVO FORM
        		if(request.getParameter(action).equals("new")) {
        			exitAddress = "/WEB-INF/view/user-list.jsp";
                	redirect = true;
        			break;
        		} else if(request.getParameter(action).equals("list")) {
        			exitAddress = "/WEB-INF/view/user-list.jsp";
                	redirect = true;
        			break;
        		}
            default:
            	exitAddress = "index.jsp";
            	redirect = false;
                break;
            }
            
            if(redirect) {
            	request.getRequestDispatcher(exitAddress).forward(request, response);
            } else {
            	response.sendRedirect(exitAddress);
            }
            
        } catch (Exception ex) {
            ex.printStackTrace();
        }
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doGet(request, response);
	}
	
	protected Integer getParamInt(HttpServletRequest request, String paramName) {
		 if(request.getParameter(paramName) != null && !request.getParameter(paramName).isEmpty()) {
		 	String paramId = request.getParameter(paramName);
			return Integer.valueOf(paramId);
		 }
		 return 0;
	}
	
	protected String getParamString(HttpServletRequest request, String paramName) {
		 if(request.getParameter(paramName) != null) {
			return request.getParameter(paramName);
		 }
		 return null;
	}

}

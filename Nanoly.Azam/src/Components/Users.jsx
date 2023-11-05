import { NavLink, Outlet } from "react-router-dom";
const Users = () => {
  const navLinkStyles = ({ isActive }) => {
    return {
      fontWeight: isActive ? "bold" : "normal",
      textDecoration: "none",
      fontSize: "2rem",
      color: "darkblue",
      fontStyle: "italic",
    };
  };
  return (
    <>
      <section
        style={{
          padding: "1rem",
          fontSize: 20,
          color: "darkblue",
          textAlign: "center",
        }}
      >
        <h1>
          <NavLink style={navLinkStyles} to="1">
            User 1
          </NavLink>
        </h1>
        <h1>
          <NavLink style={navLinkStyles} to="2">
            User 2
          </NavLink>
        </h1>
        <h1>
          <NavLink style={navLinkStyles} to="3">
            User 3
          </NavLink>
        </h1>
        <h1>
          <NavLink style={navLinkStyles} to="admin">
            User Admin
          </NavLink>
        </h1>
      </section>
      <section>
        <Outlet />
      </section>
    </>
  );
};
export default Users;

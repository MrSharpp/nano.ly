import { NavLink } from "react-router-dom";
const NavBar = () => {
  const navLinkStyles = ({ isActive }) => {
    return {
      fontWeight: isActive ? "bold" : "normal",
      textDecoration: "none",
      fontSize: "2rem",
      color: "brown",
      fontStyle: "italic",
    };
  };
  return (
    <>
      <nav
        style={{
          backgroundColor: "gainsboro",
          padding: "1rem",
          margin: 0,
          display: "flex",
          gap: "2rem",
          justifyContent: "center",
        }}
      >
        <NavLink style={navLinkStyles} to="/">
          Home
        </NavLink>
        <NavLink style={navLinkStyles} to="/about">
          About
        </NavLink>
        <NavLink style={navLinkStyles} to="/products">
          Products
        </NavLink>
        <NavLink style={navLinkStyles} to="/users">
          Users
        </NavLink>
      </nav>
    </>
  );
};
export default NavBar;

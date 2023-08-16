import Layout from "./Layout/MainLayout";
import {
  createBrowserRouter,
  Navigate,
  RouterProvider,
} from "react-router-dom";
import Home from "./pages/Home";
import Explore from "./pages/Explore";
import Profile from "./pages/Profile";
import IndividualPosts from "./pages/IndividualPosts";
import Register from "./pages/Register";
import Login from "./pages/Login";
import { RootState } from "./redux/store";

function App() {
  const user = useSelector((state: RootState) => state.auth.currentUser);
  const router = createBrowserRouter([
    {
      path: "/",
      element: user ? <Layout /> : <Navigate to="/login" replace />,
      children: [
        {
          path: "/",
          element: <Home />,
        },
        {
          path: "/explore",
          element: <Explore />,
        },
        {
          path: "/profile",
          element: <Profile />,
        },
        {
          path: "/p/:id",
          element: <IndividualPosts />,
        },
      ],
    },
    {
      path: "/register",
      element: <Register />,
    },
    {
      path: "/login",
      element: !user ? <Login /> : <Navigate to="/" replace />,
    },
  ]);
  return (
    <div>
      <RouterProvider router={router} />
    </div>
  );
}

export default App;

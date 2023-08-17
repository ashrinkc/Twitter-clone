import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { api } from "../config/data";

interface IUserAuth {
  username: string;
  password: string;
}

export interface IUserData {
  id?: number;
  email?: string;
  username?: string;
  password?: string;
  joinDate?: string;
}

export const userLogin = createAsyncThunk(
  "login",
  async (data: IUserAuth, { dispatch }) => {
    dispatch(loginStart());
    try {
      const res = await axios.post(`${api}/login`, data);
      console.log(res.data);
      dispatch(loginSuccess(res.data));
      return true;
    } catch (err) {
      dispatch(loginFailure());
      console.log(err);
      return false;
    }
  }
);

export const authSlice = createSlice({
  name: "login",
  initialState: {
    currentUser: {
      id: null,
      email: null,
      username: null,
      password: null,
      joinDate: null,
    },
    isFetching: false,
    error: false,
  },
  reducers: {
    loginStart: (state) => {
      state.isFetching = true;
      state.error = false;
    },
    loginSuccess: (state, action) => {
      state.isFetching = false;
      state.currentUser = action.payload;
      // let expiresAt = Date.now() + 900000;
      // localStorage.setItem(
      //   "user",
      //   JSON.stringify({ ...action.payload.token, expiresAt })
      // );
    },
    loginFailure: (state) => {
      state.isFetching = false;
      state.error = true;
    },
    clearCurrentUser: (state) => {
      state.currentUser = {
        id: null,
        email: null,
        username: null,
        password: null,
        joinDate: null,
      };
    },
  },
});

export const { loginStart, loginSuccess, loginFailure, clearCurrentUser } =
  authSlice.actions;
export default authSlice.reducer;

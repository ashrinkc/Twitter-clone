import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { api } from "../config/data";

export const userLogin = createAsyncThunk(
  "login",
  async (data: any, { dispatch }) => {
    dispatch(loginStart());
    try {
      const res = await axios.post(`${api}/login`, data);
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
    currentUser: null,
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
      state.currentUser = action.payload.user;
      let expiresAt = Date.now() + 900000;
      localStorage.setItem(
        "user",
        JSON.stringify({ ...action.payload.token, expiresAt })
      );
    },
    loginFailure: (state) => {
      state.isFetching = false;
      state.error = true;
    },
    clearCurrentUser: (state) => {
      state.currentUser = null;
    },
  },
});

export const { loginStart, loginSuccess, loginFailure } = authSlice.actions;
export default authSlice.reducer;

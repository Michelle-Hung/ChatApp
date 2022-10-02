import axios from "axios";

type LoginResponse = {
  success: boolean;
  userId: string;
};

export async function LoginAsync(name: string, password: string) {
  try {
    const { data } = await axios.post<LoginResponse>(
      `${process.env.VUE_APP_API_URL}/user/Login`,
      { name: name, password: password },
      {
        headers: {
          "Content-Type": "application/json",
          Accept: "application/json",
        },
      }
    );
    return { data };
  } catch (error) {
    const data: LoginResponse = {
      success: false,
      userId: "0",
    };
    if (axios.isAxiosError(error)) {
      console.error("error message: ", error.message);
    } else {
      console.error("unexpected error: ", error);
    }
    return { data };
  }
}

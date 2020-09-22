import React from "react";
import { Feather } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";
import { View, Image, TouchableOpacity, Text } from "react-native";
import styles from "./styles";

const Login = () => {
  const { navigate } = useNavigation();
  return (
    <View style={styles.container}>
      <Image source={require("../../assets/logo2.png")} style={styles.image} />

      <View style={styles.actions}>
        <TouchableOpacity
          style={styles.detailsButtonLogin}
          onPress={() => navigate("Feed")}
        >
          <Feather name="facebook" size={24} color="#fff" />
          <Text style={styles.detailsButtonText}> Login com Facebook </Text>
        </TouchableOpacity>
      </View>
    </View>
  );
};
export default Login;

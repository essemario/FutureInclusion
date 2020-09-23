import React, { useState, useEffect, Fragment } from "react";
import { useNavigation } from "@react-navigation/native";
import { View, FlatList, Image, Text, TouchableOpacity } from "react-native";
import loadFeed from "../../services/api";
import styles from "./styles";

const TinyProfile = ({politic}) => {
  const { navigate } = useNavigation();
  return (
    <Fragment>
      <TouchableOpacity
        style={styles.personal}
        onPress={() => navigate("Political", { name: politic.id })}
      >
        <View>
          <Text style={styles.politicalName}>{politic.politicName}</Text>
          <Text style={styles.politicalOffice}>{politic.mandateName}</Text>
        </View>
      </TouchableOpacity>
    </Fragment>
  );
};
export default TinyProfile;
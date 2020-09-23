import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';

export default StyleSheet.create({
    container: {
        flex: 1,
        paddingHorizontal: 16,
        paddingTop: Constants.statusBarHeight + 20,
     },

     postList: {
        marginTop: 32,
     },

     post: {
        padding: 24,
        borderRadius: 8,
        backgroundColor: '#fff',
        marginBottom: 16,
     }, 

     title: {
        marginTop: 8,
        marginBottom: 4,
        fontSize: 16,
        color: '#41414d',
        fontWeight: 'bold',
     },

     postVoting: {
         marginTop: 12,
         flexDirection: 'row',
         justifyContent: 'space-between',
         alignItems: 'center',
     },

     detailsButtonYes: {
         flexDirection: 'row',
         justifyContent: 'space-between',
         alignItems: 'center',
         paddingVertical: 8,
         paddingHorizontal: 45,
         borderRadius: 8,
         backgroundColor: "#89cbff",
         margin: 5
     },

     detailsButtonNo: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        paddingVertical: 8,
        paddingHorizontal: 45,
        borderRadius: 8,
        backgroundColor: "#ffc0cb",
    },

    detailsButtonText: {
        fontSize: 14,
        fontWeight: 'bold',
    },
});
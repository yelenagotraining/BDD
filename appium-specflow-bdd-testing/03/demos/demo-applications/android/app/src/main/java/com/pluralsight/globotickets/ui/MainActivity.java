package com.pluralsight.globotickets.ui;

import android.content.Context;
import android.graphics.Color;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.view.KeyEvent;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.pluralsight.globotickets.databinding.ActivityMainBinding;

import java.util.Locale;

public class MainActivity extends AppCompatActivity {

    private ActivityMainBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        binding.upfrontPaymentPercentage.setEnabled(false);
        binding.progressBar.setVisibility(View.INVISIBLE);

        binding.upfrontPayment.setOnCheckedChangeListener((button, value) -> {
            binding.upfrontPaymentPercentage.setEnabled(value);
            if (!value) {
                binding.upfrontPaymentPercentage.setText("");
            }
        });

        binding.calculateBtn.setOnClickListener((view) -> {
            binding.result.setText("");
            binding.progressBar.setVisibility(View.INVISIBLE);

            Integer numberOfGuests;
            Integer upfrontPaymentPercentage = 0;
            Integer venueCapacity = -1;
            Double venuePrice;
            Double servicePrice = 0.0;

            try {
                numberOfGuests = Integer.parseInt(binding.numberOfGuests.getText().toString());
                if (binding.upfrontPayment.isChecked()) {
                    upfrontPaymentPercentage = Integer.parseInt(binding.upfrontPaymentPercentage.getText().toString());
                }
            } catch (NumberFormatException e) {
                binding.result.setTextColor(Color.RED);
                binding.result.setText("Please enter all data.");
                return;
            }

            switch (binding.venue.getSelectedItem().toString().toLowerCase(Locale.ROOT)) {
                case "city hall":
                    venueCapacity = 200;
                    venuePrice = 2500.0;
                    break;
                case "main building":
                    venueCapacity = 400;
                    venuePrice = 5000.0;
                    break;
                case "retro lounge":
                    venueCapacity = 500;
                    venuePrice = 7000.0;
                    break;
                default:
                    return;
            }

            if (venueCapacity < numberOfGuests) {
                binding.result.setTextColor(Color.RED);
                binding.result.setText("Selected venue cannot accept the desired number of guests.");
                return;
            }

            binding.progressBar.setVisibility(View.VISIBLE);

            switch (binding.serviceLevel.getSelectedItem().toString().toLowerCase(Locale.ROOT)) {
                case "basic":
                    servicePrice = 100.0;
                    break;
                case "premium":
                    servicePrice = 150.0;
                    break;
                default:
                    break;
            }

            Double paymentQuantifier = 1.0;

            if (upfrontPaymentPercentage > 9) {
                paymentQuantifier = 0.9;
            }

            if (upfrontPaymentPercentage > 49) {
                paymentQuantifier = 0.8;
            }

            Double calculationResult =
                    (numberOfGuests * servicePrice + venuePrice) * paymentQuantifier + (binding.promotionIncluded.isChecked() ? 500.0 : 0);

            Double randomDelay = Math.random() * (6000 - 2000 + 1) + 2000;
            new CountDownTimer(randomDelay.longValue(), 1000) {
                public void onFinish() {
                    binding.progressBar.setVisibility(View.INVISIBLE);

                    binding.result.setTextColor(Color.GREEN);
                    binding.result.setText("Total cost is: $" + calculationResult);
                }

                public void onTick(long millisUntilFinished) { }
            }.start();
        });

        binding.clearBtn.setOnClickListener((view) -> {
            binding.numberOfGuests.setText("");
            binding.venue.setSelection(0);
            binding.serviceLevel.setSelection(0);
            binding.promotionIncluded.setChecked(false);
            binding.upfrontPayment.setChecked(false);
            binding.upfrontPaymentPercentage.setText("");

            binding.result.setText("");
            binding.progressBar.setVisibility(View.INVISIBLE);
        });
    }
}